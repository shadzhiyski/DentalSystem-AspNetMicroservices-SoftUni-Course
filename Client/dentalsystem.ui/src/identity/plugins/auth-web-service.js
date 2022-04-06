"use strict";

import { AxiosWebServiceBuilder } from '../../common/plugins/axios-web-service-builder'

let config = {
  baseURL: process.env.VUE_APP_IDENTITY_BASE_URL,
  headers: {
    "apikey": process.env.VUE_APP_IDENTITY_API_KEY
  }
};

export default new AxiosWebServiceBuilder()
  .withConfig(config)
  .build();
