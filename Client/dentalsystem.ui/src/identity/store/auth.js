import webService from "../../common/plugins/auth-web-service";

const state = {
  username: localStorage.getItem('username') || null,
  authToken: localStorage.getItem('authToken') || null
};

const getters = {
  isAuthenticated: (state) => !!state.username,
  username: (state) => state.username,
  authToken: (state) => state.authToken,
  authTokenData: (state) => {
    var rawData = state.authToken
    ? JSON.parse(atob(state.authToken.split('.')[1]))
    : {};

    var resultData = {
      username: rawData['unique_name'],
      role: rawData['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],

    };

    if (resultData.role == 'Patient') {
      resultData.patientReferenceId = rawData['ReferenceId']
    } else {
      resultData.dentalTeamReferenceId = rawData['ReferenceId']
    }

    return resultData;
  }
};

const actions = {

  async logIn({commit}, userCredentials) {
    userCredentials.email = userCredentials.username;
    var response = await webService.post("Identity/Login", userCredentials);

    await commit("setUser", userCredentials.username);
    await commit("setAuthToken", response.token);
  },

  async register({commit}, userInputData) {
    userInputData.email = userInputData.username;
    var response = await webService.post("Identity/Register", userInputData);

    await commit("setUser", userInputData.username);
    await commit("setAuthToken", response.token);
  },

  async logOut({ commit }) {
    commit("logout");
  },
};

const mutations = {
  setUser(state, username) {
    localStorage.setItem('username', username);
    state.username = username;
  },

  setAuthToken(state, authToken) {
    localStorage.setItem('authToken', authToken);
    state.authToken = authToken;
  },

  logout(state) {
    localStorage.removeItem('username');
    localStorage.removeItem('authToken');
    state.username = null;
    state.authToken = null;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};