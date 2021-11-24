"use strict";

import { AxiosWebServiceBuilder } from '../../common/plugins/axios-web-service-builder'

let config = {
  baseURL: 'https://localhost:4002/',
  // timeout: 60 * 1000, // Timeout
  // withCredentials: true, // Check cross-site Access-Control
};

export default new AxiosWebServiceBuilder()
  .withConfig(config)
  .withAuthorization()
  .build();
