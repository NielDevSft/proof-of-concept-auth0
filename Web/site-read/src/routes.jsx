import React, { Component } from 'react'
import { Router, Route } from 'react-router'

import Component1 from './components/component1'
import Header from './containers/header'
import history from './utils/history'
// import Container1 from './containers/container1'

class Routes extends Component {
    render() {
        return (
            <div>
                <Router history={history}>
                    <div>
                        <Header />
                             <Route path="/component1" component={Component1}>

                        </Route>

                    </div>
                </Router>
            </div>
        )
    }
}

export default Routes