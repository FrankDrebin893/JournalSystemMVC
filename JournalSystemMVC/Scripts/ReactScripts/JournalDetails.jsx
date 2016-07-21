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
                {entryNodes}
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
        var date = this.props.entry.EntryDate,
            formattedDate = (new Date(date)).toUTCString();

        return (
            <div className="entryContainer">
                <div className="entryHeader">
                    <strong>{formattedDate}</strong>
                    <br/>
                    by {this.props.entry.Author.FirstName} {this.props.entry.Author.LastName}
                    
                </div>
                <div className="entryContent">{this.props.entry.EntryText} </div>
            </div>
                    );
                }
});

