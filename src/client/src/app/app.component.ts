import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [
      HeaderComponent,
      RouterModule
    ],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']    
})
export class AppComponent {
  title = 'FlowerShop';
}