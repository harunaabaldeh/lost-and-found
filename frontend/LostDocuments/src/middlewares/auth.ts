// middleware/auth.ts
import { RouteLocationNormalized, NavigationGuardNext } from "vue-router";

export const isAuthenticated = (
  to: RouteLocationNormalized,
  from: RouteLocationNormalized,
  next: NavigationGuardNext
): void => {
  if (localStorage.getItem("token")) {
    next();
  } else {
    next({ name: "Login" });
  }
};
