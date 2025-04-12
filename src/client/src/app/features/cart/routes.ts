import { Route } from "@angular/router";
import { CartComponent } from "./cart.component";

export const shopRoutes: Route[] = [
  {
    path: ':cartId',
    component: CartComponent,
    data: { breadcrumb: 'Your cart' },
  }
];