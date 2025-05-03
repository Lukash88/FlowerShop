import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatCard, MatCardTitle } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';

@Component({
    selector: 'app-home',
    standalone: true,
    imports: [
      CommonModule,
      MatCard,
      MatCardTitle,
      MatIcon
    ],
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  slides = [
    { image: 'assets/images/hero/hero1.jpg', title: 'Beautiful Bouquets' },
    { image: 'assets/images/hero/hero2.jpg', title: 'Fresh Arrivals' },
    { image: 'assets/images/hero/hero3.jpg', title: 'Seasonal Specials' }
  ];
  
  currentSlide = 0;
  
  nextSlide() {
    this.currentSlide = (this.currentSlide + 1) % this.slides.length;
  }
  
  prevSlide() {
    this.currentSlide = (this.currentSlide - 1 + this.slides.length) % this.slides.length;
  }
}