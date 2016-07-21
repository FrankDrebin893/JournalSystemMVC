var ResidentBox = React.createClass({
    propTypes: {
        resident: React.PropTypes.object.isRequired
    },
    getInitialState() {
        return{
            firstName: this.props.resident.FirstName
        };
    },
    render() {
        return (
            <div> First name: {this.props.resident.FirstName}</div>
        );
}
});

/*ReactDOM.render(
  <ResidentBox />,
  document.getElementById('residentContent')
);*/