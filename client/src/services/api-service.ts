/* eslint @typescript-eslint/no-explicit-any: 0 */

import { HttpMethods } from "@/models/http-methods";
import { API_URL } from "@/config/config";

export type RequestData = {
  endpoint: string; 
  method: HttpMethods; 
  body: any;
}

export class ApiService {
  private headers = {
    "Content-Type": "application/json",
    Authorization: "",
  }

  private baseendpoint = API_URL;

  set Authorization(value: string) {
    this.headers.Authorization = `Bearer ${value}`;
  }

  private fetch(request: RequestData): Promise<Response> {
    return fetch(`${this.baseendpoint}${request.endpoint}`, {
      method: request.method.toString(), 
      headers: this.headers,
      body: JSON.stringify(request.body),
    });
  }

  Get(endpoint: string, body: any) {
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Get,
    };

    return this.fetch(request);
  }

  Post(endpoint: string, body: any) {    
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }

  Put(endpoint: string, body: any) {
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }

  Delete(endpoint: string, body: any) {
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }

  Patch(endpoint: string, body: any) {
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }
}

export const apiService = new ApiService();
