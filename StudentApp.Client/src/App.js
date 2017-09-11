import React, { Component } from 'react';
import StudentsList from './StudentsList';
import GroupsList from './GroupsList';
import Home from './Home';
import NavBar from './NavBar';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom'

class App extends Component {
  render() {
    return (
      <div className="container">
        <Router>
          <div>
            <NavBar />
            <Switch>
              <Route path="/" exact component={Home} />
              <Route path="/students" exact component={StudentsList} />
              <Route path="/groups" exact component={GroupsList} />
            </Switch>
          </div>
        </Router>
      </div>

    );
  }
}

export default App;
