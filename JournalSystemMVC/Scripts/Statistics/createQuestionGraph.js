
function getQuestionData(userId, callback) {
    $.ajax({
        type: 'GET',
        url: 'GetQuestionData',
        data: { id: 1003 },
        dataType: 'application/json',
        success: callback,
        error: function () {
            alert('Error during AJAX request');
        }
    });
}

function randomDate(start, i) {
    return new Date(start.getTime() + i);
}

var chart;
var data;
var randomizeFillOpacity = function () {
    var rand = Math.random(0, 1);
    for (var i = 0; i < 100; i++) { // modify sine amplitude
        data[4].values[i].y = Math.sin(i / (5 + rand)) * .4 * rand - .25;
    }
    data[4].fillOpacity = rand;
    chart.update();
};

// This function formats received JSON results, so that it's usable for the graph, since the JavaScript Serializer doesn't format the dates correctly.
function formatAnswerData(json) {
    var scores = [];
    var data = JSON.parse(json);
    var answer;
    var dateValue;
    var formattedDate;
    var score;

    for (var i = 0; i < data.Answers.length; i++) {
        answer = data.Answers[i];
        dateValue = answer.x;
        formattedDate = new Date(parseInt(dateValue.replace("/Date(", "").replace(")/", ""), 10));
        score = answer.y;
        scores.push({ x: formattedDate, y: score });
    }

    return [
        {
            area: true,
            values: scores,
            key: data.QuestionText,
            color: "#ff7f0e",
            strokeWidth: 5
        }
    ];
}

function createQuestionLineChart(id, residentId) {
    d3.json('GetQuestionData/?id='+id+'&residentId='+residentId, function (error, json) {
        if (error) return console.warn(error);
        nv.addGraph(function () {
            data = formatAnswerData(json);
            chart = nv.models.lineChart()
                .options({
                    duration: 300,
                    useInteractiveGuideline: true
                });
            chart.xAxis
                .axisLabel("Date (s)")
                .tickFormat(function(d) { return d3.time.format('%b %d %Y')(new Date(d)); })
                .staggerLabels(true);
            chart.yAxis
                .axisLabel('Score (v)')
                .tickFormat(function(d) {
                    if (d == null) {
                        return 'N/A';
                    }
                    return d3.format(',.2f')(d);
                });
            d3.select('#chart2').append('svg')
                .datum(data)
                .call(chart);
            nv.utils.windowResize(chart.update);
            return chart;
        });
        return chart;
    });
}