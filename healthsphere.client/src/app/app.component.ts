import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

enum AccountTypes {
  Patient,
  Doctor,
  Staff,
}

interface UserCredentialsDto {
  username: string;
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  accountType: AccountTypes;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  constructor(private http: HttpClient) { }

  ngOnInit() {
    //this.signIn();
    //this.signUp();
  }

  signIn() {
    var signInUrl = 'https://localhost:7203/api/Gateway/signIn';
    var userCredentialsDto: UserCredentialsDto = {
      username: 'georgidimitrovx',
      email: 'georgidimitrovx@gmail.com',
      password: 'qwerty',
      firstName: 'Georgi',
      lastName: 'Dimitrov',
      accountType: AccountTypes.Staff
    }

    this.http.post<any>(signInUrl, userCredentialsDto).subscribe({
      next: (response) => {
        console.log('Sign in successful', response);
        // Handle successful sign in
      },
      error: (error) => {
        console.error('Sign in failed', error);
        // Handle sign in error
      }
    });
  }

  signUp() {
    var signUpUrl = 'https://localhost:7203/api/Gateway/signUp';
    var userCredentialsDto: UserCredentialsDto = {
      username: 'georgidimitrovx',
      email: 'georgidimitrovx@gmail.com',
      password: 'qwerty',
      firstName: 'Georgi',
      lastName: 'Dimitrov',
      accountType: AccountTypes.Staff
    }

    this.http.post<any>(signUpUrl, userCredentialsDto).subscribe({
      next: (response) => {
        console.log('Sign up successful', response);
        // Handle successful sign in
      },
      error: (error) => {
        console.error('Sign up failed', error);
        // Handle sign in error
      }
    });
  }

  title = 'healthsphere.client';
}
