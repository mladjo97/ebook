import { combineReducers } from 'redux';

import categoriesReducer from './categories';
import eBooksReducer from './ebooks';

const rootReducer = combineReducers({
  categoriesReducer,
  eBooksReducer
});

export default rootReducer;