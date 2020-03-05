import {
  SEARCH_EBOOKS_REQUEST,
  SEARCH_EBOOKS_SUCCESS,
  SEARCH_EBOOKS_FAILURE
} from '../actions/ebooks';


const initialState = {
  eBooks: [],
  isFetched: false,
  error: false
}

const reducer = (state = initialState, action) => {
  switch(action.type) {
    case SEARCH_EBOOKS_REQUEST:
      return {
        ...state,
        isFetched: false,
        error: false
      }
    case SEARCH_EBOOKS_SUCCESS:
      return {
        ...state,
        eBooks: action.payload.items,
        isFetched: true,
        error: false
      }
    case SEARCH_EBOOKS_FAILURE:
      return {
        ...state,
        error: true
      }
    default:
      return {
        ...state
      }    
  }
};

export default reducer;

export const eBooksSelector = state => state.eBooksReducer.eBooks;
export const isFetchedSelector = state => state.eBooksReducer.isFetched;
export const errorSelector = state => state.eBooksReducer.error;