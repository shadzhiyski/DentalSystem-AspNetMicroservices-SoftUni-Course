import schedulingWebService from "../../scheduling/plugins/scheduling-web-service";

const state = {
  treatmentSession: {},
  treatmentSessions: []
};

const getters = {
  treatmentSession: (state) => state.treatmentSession,
  allTreatmentSessions: (state) => state.treatmentSessions,
};

const actions = {
  async getTreatmentSession({commit}, referenceId) {
    let response = await schedulingWebService.get('treatmentSession/', { params: { referenceId: referenceId } });

    const responseData = response.data;
    const treatmentSessionData = {
      referenceId: responseData.referenceId,
      dentalTeamReferenceId: responseData.dentalTeamReferenceId,
      patientReferenceId: responseData.patientReferenceId,
      treatmentReferenceId: responseData.treatmentReferenceId,
      start: responseData.start,
      startDate: responseData.start.substr(0, 10),
      startTime: responseData.start.substr(11, 5),
      end: responseData.end,
      status: responseData.status
    }

    await commit("setTreatmentSession", treatmentSessionData);
  },
  async updateTreatmentSession({commit}, treatmentSessionData) {
    await schedulingWebService.put('treatmentSession',treatmentSessionData);
    await commit("setTreatmentSession", treatmentSessionData);
  },
  async acceptTreatmentSession({commit}, treatmentSessionData) {
    await schedulingWebService.post('treatmentSession/accept', null, { params: { referenceId: treatmentSessionData.referenceId } });
    await commit("setTreatmentSession", treatmentSessionData);
  },
  async rejectTreatmentSession({commit}, treatmentSessionData) {
    await schedulingWebService.post('treatmentSession/reject', null, { params: { referenceId: treatmentSessionData.referenceId } });
    await commit("setTreatmentSession", treatmentSessionData);
  },
  async createTreatmentSession({commit}, treatmentSessionData) {
    await schedulingWebService.post('treatmentSession/request',treatmentSessionData);
    await commit("setTreatmentSession", treatmentSessionData);
  },
  async getPatientTreatmentSessions({commit}) {
    let response = await schedulingWebService.get('treatmentSession/patient');

    await commit("setTreatmentSessions", response.data);
  },
  async getDentalTeamTreatmentSessions({commit}) {
    let response = await schedulingWebService.get('treatmentSession/dentalTeam');

    await commit("setTreatmentSessions", response.data);
  },
};

const mutations = {
  setTreatmentSessions(state, treatmentSessions) {
    state.treatmentSessions = treatmentSessions;
  },
  setTreatmentSession(state, treatmentSession) {
    state.treatmentSession = treatmentSession;
  }
};

export default {
  state,
  getters,
  actions,
  mutations,
};