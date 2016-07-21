
var EntryForm = React.createClass({
    getInitialState() {
        return {
            submitUrl: this.props.submitUrl
        };
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var text = this.refs.text.value.trim();
        this.handleEntrySubmit({ Text: text });
        this.refs.text.value = '';
        return;
    },
    render: function() {
        return (
                <form className="entryForm" onSubmit={this.handleSubmit}>
                    <input type="text" placeholder="Place new entry in this journal" ref="text"/>
                    <input type="submit" value="Post"/>
                </form>
        );
},
handleEntrySubmit: function (entry) {
    var data = new FormData();
    data.append('Text', entry.Text);

    var xhr = new XMLHttpRequest();
    xhr.open('post', this.props.submitUrl, true);
    xhr.onload = function () {
        this.loadCommentsFromServer();
    }.bind(this);
    xhr.send(data);
}
});

var CommentBox = React.createClass({
    displayName: 'CommentBox',
    render: function () {
        return (
          React.createElement('div', { className: "commentBox" },
            "Hello, world! I am a CommentBox."
          )
        );
    }
});

ReactDOM.render(
  <EntryForm />,
  document.getElementById('entryFormContainer')
);