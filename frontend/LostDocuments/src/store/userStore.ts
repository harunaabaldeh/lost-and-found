import { defineStore } from "pinia";
import agent from "../api/agent";
import router from "../routes/router";

const useUserStore = defineStore("user-store", {
  state: () => ({
    user: JSON.parse(localStorage.getItem("token") ?? "null"),
    isAuthenticated: false,
  }),
  getters: {
    // computed properties goes here
  },
  actions: {
    async register(fullName: string, address: string, username: string, email: string, password: string) {
      await agent
        .post("/api/auth/register", { fullName, address, username, email, password })
        .then((res) => {
          if (res.status === 200) {
            this.isAuthenticated = true;
            this.user = res.data;
            localStorage.setItem("token", JSON.stringify(this.user.token));
            router.push("/");
            console.log(this.user);
          }
        })
        .catch((err) => {
          console.log(err);
        });
    },    async login(username: string, password: string) {
      await agent
        .post("/api/auth/login", { username, password })
        .then((res) => {
          if (res.status === 200) {
            this.isAuthenticated = true;
            this.user = res.data;
            localStorage.setItem("token", JSON.stringify(this.user.token));
            router.push("/");
            console.log(this.user);
          }
        })
        .catch((err) => {
          console.log(err);
        });
    },
    async logout() {
      localStorage.removeItem("token");
      this.isAuthenticated = false;
      router.push("/");
    },
  },
});

export default useUserStore;
