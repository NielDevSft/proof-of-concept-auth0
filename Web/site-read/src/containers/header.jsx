import React, { Component } from 'react'
import { Link } from 'react-router-dom'

class Header extends Component {
    render() {
        return (
            <div>
                <Link to='/component1' ></Link>
                <Link to='/container1' ></Link>
            </div>
        )
    }
}

export default Header;