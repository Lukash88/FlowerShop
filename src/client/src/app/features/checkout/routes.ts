import { Route } from "@angular/router";
import { CheckoutComponent } from "./checkout.component";
import { CheckoutSuccessComponent } from "./checkout-success/checkout-success.component";
import { AuthGuard } from "src/app/core/guards/auth.guard";

export const checkoutRoutes: Route[] = [
  { path: '', component: CheckoutComponent, canActivate: [AuthGuard] },
  { path: 'success', component: CheckoutSuccessComponent }
];