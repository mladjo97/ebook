import {
  GET_CATEGORIES_REQUEST,
  GET_CATEGORIES_SUCCESS,
  GET_CATEGORIES_FAILURE
} from '../actions/categories';

const initialState = {
  categories: [],
  isFetched: false,
  error: false
};

const reducer = (state = initialState, action) => {
  switch (action.type) {
    case GET_CATEGORIES_REQUEST:
      return {
        ...state,
        isFetched: false,
        error: false
      }

    case GET_CATEGORIES_SUCCESS:
      return {
        ...state,
        categories: action.payload,
        isFetched: true,
        error: false
      }

    case GET_CATEGORIES_FAILURE:
      return {
        ...state,
        error: true // assign object here?
      }
    
    default:
      return {
        ...state
      }
  }
}

export const categoriesSelector = state => state.categoriesReducer.categories;
export const isFetchedSelector = state => state.categoriesReducer.isFetched;
export const errorSelector = state => state.categoriesReducer.error;

export default reducer;