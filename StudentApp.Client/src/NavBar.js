import React, { Component } from 'react';
import { Link } from 'react-router-dom'

class NavBar extends Component {

    render() {
        return (
            <div className="navbar navbar-inverse navbar-fixed-top" id="menu">
                <div className="container">
                    <div className="navbar-header">
                        <button type="button" className="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                        </button>

                    </div>
                    <div className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            <li><Link to="/">Home</Link></li>
                            <li><Link to="/students">Students</Link></li>
                            <li><Link to="/groups">Groups</Link></li>
                        </ul>
                    </div>
                </div>
            </div>

        );
    }
}

export default NavBar;

