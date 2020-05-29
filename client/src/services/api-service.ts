/* eslint @typescript-eslint/no-explicit-any: 0 */

import { HttpMethods } from "@/models/http-methods";

export type RequestData = {
  url: string; 
  method: HttpMethods; 
  body: any;
}

export class ApiService {
  private headers = {
    "Content-Type": "application/json",
    Authorization: "",
  }

  set Authorization(value: string) {
    this.headers.Authorization = `Bearer ${value}`;
  }

  private fetch(request: RequestData): Promise<Response> {
    return fetch(request.url, {
      method: request.method.toString(), 
      headers: this.headers,
      body: JSON.stringify(request.body),
    });
  }

  Get(url: string, body: any) {
    const request: RequestData = {
      url, 
      body,
      method: HttpMethods.Get,
    };

    return this.fetch(request);
  }

  Post(url: string, body: any) {    
    const request: RequestData = {
      url, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }

  Put(url: string, body: any) {
    const request: RequestData = {
      url, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }

  Delete(url: string, body: any) {
    const request: RequestData = {
      url, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }

  Patch(url: string, body: any) {
    const request: RequestData = {
      url, 
      body,
      method: HttpMethods.Get,
    };
    
    return this.fetch(request);
  }
}

export const apiService = new ApiService();
