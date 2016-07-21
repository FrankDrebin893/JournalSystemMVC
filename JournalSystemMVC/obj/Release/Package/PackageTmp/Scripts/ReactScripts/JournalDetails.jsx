var JournalEntriesList = React.createClass({
    propTypes: {
        entries: React.PropTypes.array.isRequired
    },
    getInitialState() {
        return {
            entries: this.props.entries,
            page: this.props.page,
            hasMore: true,
            loadingMore: false
        };
    },
    loadMoreClicked(evt) {
        var nextPage = this.state.page + 1;
        this.setState({
            page: nextPage,
            loadingMore: true
        });

        var url = evt.target.href;
        var xhr = new XMLHttpRequest();
        xhr.open('GET', url, true);
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.onload = () => {
            var data = JSON.parse(xhr.responseText);
            this.setState({
                entries: this.state.entries.concat(data.entries),
                hasMore: data.hasMore,
                loadingMore: false
            });
        };
        xhr.send();
        evt.preventDefault();
    },
    render() {
        var entryNodes = this.state.entries.map(entry =>
            <JournalEntry entry={entry}>{entry.EntryText}</JournalEntry>
        );

        return (
            <div className="entries">
                <h1>Entries</h1>
                <ol className="entryList">
                    {entryNodes}
                </ol>
                {this.renderMoreLink()}
            </div>

        );
    },
        renderMoreLink() {
            if (this.state.loadingMore) {
                return <em>Loading...</em>;
            } else if (this.state.hasMore) {
                return (
				    <a href={'/entries/page-' + (this.state.page + 1)} onClick={this.loadMoreClicked}>
					    Load older entries
				    </a>
			    );
        } else {
                return <em>No more entries</em>;
    }
}
});

var JournalEntry = React.createClass({
    propTypes: {
        entry: React.PropTypes.object.isRequired
    },
    render() {
        return (
            <li>
            {this.props.entry.EntryText}
            <strong>{this.props.entry.EntryDate}</strong>
             </li>
            );
    }
});