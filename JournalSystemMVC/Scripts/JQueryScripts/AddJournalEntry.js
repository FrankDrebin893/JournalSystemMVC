$(".entryButton").click(function() {
    $.ajax({
        type: "POST",
        url: "Journals/AddEntry",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            // Do something interesting here.
        }
    });
});