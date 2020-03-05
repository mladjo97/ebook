import axios from 'axios';
import config from '../../config';

const instance = axios.create({
  baseURL: config.api.baseUrl,
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json'
  }
});

export default instance;