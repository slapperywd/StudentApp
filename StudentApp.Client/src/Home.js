import React, { Component } from 'react';

class Home extends Component {
  render() {
    return (
      <div className="jumbotron">
        <h1>Stud app</h1>
        <p>Simple representation of ASP.NET WebAPI 2 Student app.</p>
        <p>Use the menu above to see the data taken from API. Make sure that your server is run.</p>
      </div>

    );
  }
}

export default Home;