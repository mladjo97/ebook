import { RSAA } from 'redux-api-middleware';

import config from '../../config';

export const GET_CATEGORIES_REQUEST = 'GET_CATEGORIES_REQUEST';
export const GET_CATEGORIES_SUCCESS = 'GET_CATEGORIES_SUCCESS';
export const GET_CATEGORIES_FAILURE = 'GET_CATEGORIES_FAILURE';

export const getCategories = () => dispatch => {
  return dispatch({
    [RSAA]: {
      endpoint: `${config.api.baseUrl}/categories`,
      method: 'GET',
      types: [
        GET_CATEGORIES_REQUEST,
        GET_CATEGORIES_SUCCESS,
        GET_CATEGORIES_FAILURE
      ]
    }
  });
}