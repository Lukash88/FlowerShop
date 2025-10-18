import { Route } from "@angular/router";
import { CheckoutComponent } from "./checkout.component";
import { CheckoutSuccessComponent } from "./checkout-success/checkout-success.component";
import { authGuard } from "src/app/core/guards/auth.guard";
import { emptyCartGuard } from "src/app/core/guards/empty-cart.guard";
import { orderCompleteGuard } from "src/app/core/guards/order-complete.guard";

export const checkoutRoutes: Route[] = [
  { path: '', component: CheckoutComponent, canActivate: [authGuard, emptyCartGuard] },
  { path: 'success', component: CheckoutSuccessComponent, canActivate: [authGuard, orderCompleteGuard] }
];