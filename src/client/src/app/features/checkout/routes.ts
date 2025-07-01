import { Route } from "@angular/router";
import { CheckoutComponent } from "./checkout.component";
import { CheckoutSuccessComponent } from "./checkout-success/checkout-success.component";
import { authGuard } from "src/app/core/guards/auth.guard";

export const checkoutRoutes: Route[] = [
  { path: '', component: CheckoutComponent, canActivate: [authGuard] },
  { path: 'success', component: CheckoutSuccessComponent, canActivate: [authGuard] }
];