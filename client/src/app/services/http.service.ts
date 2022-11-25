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

  get(path: string): Observable<any> {
    return this.httpClient.get(this.api_url + path);
  } 

  post(path: string, body: object): Observable<any> {
    return this.httpClient.post(this.api_url + path, body);
  }
}
