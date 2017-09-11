import React, { Component } from 'react';
import axios from 'axios';

class GroupsList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      groups: []
    };
  }

  componentDidMount() {
    axios.get(`http://localhost:63348/api/Group/`)
      .then(res => this.setState({ groups: res.data }),
      err => console.log(err));
  }
  render() {
    return (
      <div className="groups-list">
        <h2>Groups list</h2>
        <div className="row">
          {this.state.groups.map(group =>
            <div key={group.Id} className="col-md-8 col-md-offset-2 item">
              <h3 className="text-center">Group ID: {group.Id}</h3>
              <h4 className="text-center">Group name: {group.Name}</h4>
            </div>
          )}
        </div>
      </div>

    );
  }
}
export default GroupsList;