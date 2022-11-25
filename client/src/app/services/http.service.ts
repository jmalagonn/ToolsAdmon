import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  api_url = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  get<T>(path: string): Observable<T> {
    return this.httpClient.get<T>(this.api_url + path);
  } 

  post<T>(path: string, body: object): Observable<T> {
    return this.httpClient.post<T>(this.api_url + path, body);
  }
}
