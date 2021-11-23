const identityRoutes = [
    {
        showOn: 'NonAuthorized',
        path: "/auth/login",
        name: "Login",
        component: () => import("../views/Login.vue"),
    },
    {
        showOn: 'NonAuthorized',
        path: "/auth/register",
        name: "Register",
        component: () => import("../views/Register.vue"),
    }
];

export default identityRoutes;
