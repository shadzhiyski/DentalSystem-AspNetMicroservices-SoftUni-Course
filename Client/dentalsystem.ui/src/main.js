import Vue from 'vue'
import App from './App.vue'
import router from './common/router'
import store from './common/store'
import vuetify from './common/plugins/vuetify'

Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
