import React, { Component } from 'react';
import * as ACTION from '../store/actions/actions'

import { connect } from 'react-redux'

class Component1 extends Component {

    state = {
        counter: 0
    }

    incri = (step) => {
        this.setState({ counter: this.state.counter + Number.parseInt(step) });
    }

    decre = (step) => {
        this.setState({ counter: this.state.counter - Number.parseInt(step) })
    }


    render() {
        return (
            <div>
                <input type="numbet" value={this.state.counter} />

                <button class="btn" id="incri" onClick={() => this.incri(this.props.step)}>Incrementa</button>
                <button class="btn" id="decre" onClick={() => this.decre(this.props.step)}>Decrementa</button>
                <br></br>
                <button onClick={() => console.log(this.props.stateprop1)}>GetState</button>
                <button onClick={() => this.props.action1()}>Dispatch Action 1</button>
                <button onClick={() => this.props.action2()}>Dispatch Action 2</button>
                <button onClick={() => this.props.action_creator1()}>Dispatch Action Create 1</button>
            </div>
        );
    }
}
function mapStateToProps(state) {
    return {
        stateprop1: state.stateprop1
    }
}
function mapDispatchToProps(dispatch) {
    return {
        action1: () => dispatch(ACTION.SUCCESS),
        action2: () => dispatch(ACTION.FAILURE)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Component1);