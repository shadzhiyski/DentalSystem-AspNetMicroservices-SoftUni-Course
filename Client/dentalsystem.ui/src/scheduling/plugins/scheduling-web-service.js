"use strict";

import { AxiosWebServiceBuilder } from '../../common/plugins/axios-web-service-builder'

let config = {
  baseURL: process.env.VUE_APP_SCHEDULING_BASE_URL
  // timeout: 60 * 1000, // Timeout
  // withCredentials: true, // Check cross-site Access-Control
};

export default new AxiosWebServiceBuilder()
  .withConfig(config)
  .withAuthorization()
  .build();
