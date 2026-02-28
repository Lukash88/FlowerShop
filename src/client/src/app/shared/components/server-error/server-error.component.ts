import { Component, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-server-error',
  standalone: true,
  imports: [MatIcon, MatButton, RouterLink],
  templateUrl: './server-error.component.html',
  styleUrl: './server-error.component.scss',
})
export class ServerErrorComponent {
  private router = inject(Router); 

  message?: string;
  failedUrl!: string;

  ngOnInit(): void {
    const state = history.state;

    this.message = state?.message;
    this.failedUrl = state?.failedUrl || '/shop';
  }

  retry(): void {
    this.router.navigateByUrl(this.failedUrl);
  }
}
