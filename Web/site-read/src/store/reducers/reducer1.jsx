import * as ACTION_TYPES from '../action-types'

const initialState = {
    success: false,
    user_text: ''
}

const rootReducer = (state = initialState, action) => {
    switch (action.type) {
        case ACTION_TYPES.SUCCESS:
            return {
                ...state,
                success : true
            }
        case ACTION_TYPES.FAILURE:
            return {
                ...state,
                success : false
            }
        case ACTION_TYPES.USER_INPUT:
            return{
                ...state,
                user_text: action.payload
            }
        default:
            return {
                state
            }
    }
}

export default rootReducer