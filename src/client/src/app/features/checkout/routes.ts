import { Route } from "@angular/router";
import { CheckoutComponent } from "./checkout.component";
import { CheckoutSuccessComponent } from "./checkout-success/checkout-success.component";
import { authGuard } from "src/app/core/guards/auth.guard";
import { emptyCartGuard } from "src/app/core/guards/empty-cart.guard";

export const checkoutRoutes: Route[] = [
  { path: '', component: CheckoutComponent, canActivate: [authGuard, emptyCartGuard] },
  { path: 'success', component: CheckoutSuccessComponent, canActivate: [authGuard] }
];