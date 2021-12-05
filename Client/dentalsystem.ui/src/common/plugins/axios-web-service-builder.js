"use strict";

import axios from "axios";
import router from '../router'
import store from '../store'

// Full config:  https://github.com/axios/axios#request-config
axios.defaults.baseURL = process.env.VUE_APP_IDENTITY_BASE_URL;
// axios.defaults.headers.common['Authorization'] = AUTH_TOKEN;
// axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';

export class AxiosWebServiceBuilder {

    withConfig(config) {
        this.config = config;

        let clone = Object.assign(Object.create(Object.getPrototypeOf(this)), this);
        return clone;
    }

    withAuthorization(hasAuthorization = true) {
        this.hasAuthorization = hasAuthorization;

        let clone = Object.assign(Object.create(Object.getPrototypeOf(this)), this);
        return clone;
    }

    build() {
        const _axios = axios.create(this.config);

        if (this.hasAuthorization) {
            _axios.interceptors.request.use(
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
        }

        // Add a response interceptor
        _axios.interceptors.response.use(
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

        return _axios;
    }
}