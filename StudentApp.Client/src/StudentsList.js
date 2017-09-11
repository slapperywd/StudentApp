import React, { Component } from 'react';
import axios from 'axios';

class StudentsList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      students: []
    };
  }

  componentDidMount() {
    axios.get(`http://localhost:63348/api/Student/`)
      .then(res => this.setState({ students: res.data }),
      err => console.log(err));
  }

  render() {
    return (
      <div className="students-list">
        <h2>Students list</h2>
        <div className="row">
          {this.state.students.map(student =>
            <div key={student.Id} className="col-md-8 col-md-offset-2 item">
              <h3 className="text-center">student ID: {student.Id}</h3>
              <h4 className="text-center">First name: {student.FirstName}</h4>
              <h4 className="text-center">Last name: {student.LastName}</h4>
              <h4 className="text-center">Faculty: {student.Faculty}</h4>
              <h4 className="text-center">Group ID: {student.Group.Id}</h4>
              <h4 className="text-center">Group name: {student.Group.Name}</h4>
            </div>
          )}
        </div>
      </div>
    );
  }
}

export default StudentsList;