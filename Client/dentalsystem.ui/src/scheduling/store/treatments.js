import schedulingWebService from "../../scheduling/plugins/scheduling-web-service";

const state = {
  treatments: []
};

const getters = {
  allTreatments: (state) => state.treatments,
};

const actions = {
  async getTreatments({commit}) {
    let response = await schedulingWebService.get("treatment/all");
    await commit("setTreatments", response.data);
  },
};

const mutations = {
  setTreatments(state, treatments) {
    state.treatments = treatments;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};