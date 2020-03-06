import { RSAA } from "redux-api-middleware";
import config from "../../config";

export const SEARCH_EBOOKS_REQUEST = 'SEARCH_EBOOKS_REQUEST';
export const SEARCH_EBOOKS_SUCCESS = 'SEARCH_EBOOKS_SUCCESS';
export const SEARCH_EBOOKS_FAILURE = 'SEARCH_EBOOKS_FAILURE';

export const searchEBooks = content => dispatch => {
  return dispatch({
    [RSAA]: {
      endpoint: `${config.api.baseUrl}/ebooks/search?content=${content}&fuzzy=true`,
      method: 'GET',
      types: [
        SEARCH_EBOOKS_REQUEST,
        SEARCH_EBOOKS_SUCCESS,
        SEARCH_EBOOKS_FAILURE
      ]
    }
  });
}