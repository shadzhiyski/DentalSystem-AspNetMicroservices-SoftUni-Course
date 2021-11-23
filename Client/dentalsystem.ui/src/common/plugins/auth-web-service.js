"use strict";

import axios from "axios";
import router from '../router'
import store from '../store'

let config = {
  baseURL: 'https://localhost:4001/',
  // timeout: 60 * 1000, // Timeout
  // withCredentials: true, // Check cross-site Access-Control
};

const _authWebService = axios.create(config);

_authWebService.interceptors.request.use(
  function(config) {
    // Do something before request is sent
    var authToken = store.getters.authToken;
    if (authToken) {
      config.headers = { ...config.headers, Authorization: `Bearer ${authToken}` };
    }

    return config;
  },
  function(error) {
    // Do something with request error
    return Promise.reject(error);
  }
);

// Add a response interceptor
_authWebService.interceptors.response.use(
  function(response) {
    // Do something with response data
    return response;
  },
  function(error) {
    // Do something with response error
    if (!error.response || error.response.status == 401) {
      store.dispatch('logOut');
      router.push({ path: '/' });
    }

    return Promise.reject(error);
  }
);

export default _authWebService;
