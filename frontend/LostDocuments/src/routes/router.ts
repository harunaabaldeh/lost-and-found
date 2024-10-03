import { createRouter, createWebHistory } from "vue-router";
import Home from "../components/Home.vue";
import LostDocumentDetails from "../components/LostDocumentDetails.vue";
import Login from "../pages/Login.vue";
import Register from "../pages/Register.vue";
import SubmitMissingDocument from "../components/SubmitMissingDocument.vue";
import { isAuthenticated } from "../middlewares/auth";
import About from "../pages/About.vue";
import ContactUs from "../pages/ContactUs.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home
    },
    {
        path: `/documents/:id`,
        name: "LostDocumentDetails",
        component: LostDocumentDetails
    },
    {
        path: '/submit-missing-document',
        name: "SubmitMissingDocument",
        component: SubmitMissingDocument,
        beforeEnter: isAuthenticated
    },
    {
        path: "/login",
        name: "Login",
        component: Login
    },
    {
        path: "/register",
        name: "Register",
        component: Register
    },
    {
        path: "/about",
        name: "About",
        component: About
    },
    {
        path: "/contact",
        name: "Contact",
        component: ContactUs
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router