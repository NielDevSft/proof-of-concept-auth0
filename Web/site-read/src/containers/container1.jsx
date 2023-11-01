import React, { Componet } from 'react'
// import Componet1 from '../components/component1'

// import * as ACTION_TYPES from '../store/action-types'
import * as ACTION from '../store/actions/actions'

import { connect } from 'react-redux'

class Container1 extends Componet {
    render() {
        return (
            <div>
                <button onClick={() => console.log(this.props.stateprop1)}>GetState</button>
                <button onClick={() => this.props.action1()}>Dispatch Action 1</button>
                <button onClick={() => this.props.action2()}>Dispatch Action 2</button>
                <button onClick={() => this.props.action_creator1()}>Dispatch Action Create 1</button>
            </div>
        )
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

export default connect(mapStateToProps, mapDispatchToProps)(Container1);