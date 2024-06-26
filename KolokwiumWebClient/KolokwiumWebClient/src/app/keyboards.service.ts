import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { KeyboardResponseDTO } from './model/keyboardResponse.interface';
import { KeyboardRequestDTO } from './model/keyboardRequest.interface';

@Injectable({
  providedIn: 'root'
})
export class KeyboardsService {

  private apiUrl: string = 'https://localhost:7092/api/Keyboards';

  constructor(private httpClient: HttpClient) { }

  
  public getKeyboards(): Observable<KeyboardResponseDTO[]> {
    return this.httpClient.get<KeyboardResponseDTO[]>(this.apiUrl);
  }

  public deleteKeyboard(keyboardId: number): Observable<void> {
    return this.httpClient.delete<void>(this.apiUrl + '/' + keyboardId);
  }

  public addKeyboard(keyboard: KeyboardRequestDTO): Observable<void> {
    return this.httpClient.post<void>(this.apiUrl, keyboard);
  }
}
