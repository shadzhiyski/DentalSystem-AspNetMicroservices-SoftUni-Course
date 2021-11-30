import schedulingWebService from "../plugins/scheduling-web-service";

const state = {
  dentalTeams: []
};

const getters = {
  allDentalTeams: (state) => state.dentalTeams,
};

const actions = {
  async getDentalTeams({commit}) {
    let response = await schedulingWebService.get('dentalTeam/all');

    await commit("setDentalTeams", response.data);
  }
};

const mutations = {
  setDentalTeams(state, dentalTeams) {
    state.dentalTeams = dentalTeams;
  }
};

export default {
  state,
  getters,
  actions,
  mutations,
};