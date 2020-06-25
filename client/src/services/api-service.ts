/* eslint @typescript-eslint/no-explicit-any: 0 */

import { HttpMethods } from "@/models/http-methods";
import { API_URL } from "@/config/config";

export type RequestData = {
  endpoint: string; 
  method: HttpMethods; 
  body?: object;
}

export class ApiService {
  private headers = {
    // "Content-Type": "multipart/form-data",
    Authorization: "",
  }

  private baseendpoint = API_URL;

  set Authorization(value: string) {
    this.headers.Authorization = `Bearer ${value}`;
  }

  private formatInputData(data: string | Date | File | null) {
    if (data instanceof Date) return data.toString();
    if (!data) return "";
  
    return data;
  }

  private convertToFormData(input: object) {
    const formData = new FormData();

    // eslint-disable-next-line no-restricted-syntax
    for (const [key, value] of Object.entries(input)) {
      const v = this.formatInputData(value);
      formData.append(key, v);
    }

    return formData;
  }
  

  private fetch(request: RequestData): Promise<Response> {
    if (!request.body) {
      throw Error(`No data has been supplied for ${request.endpoint}`);      
    }

    const body = this.convertToFormData(request.body);

    console.log(body);

    return fetch(`${this.baseendpoint}${request.endpoint}`, {
      method: request.method.toString(), 
      headers: this.headers,
      body, 
    });
  }

  Get(endpoint: string) {
    const request: RequestData = {
      endpoint,
      method: HttpMethods.Get,
    };

    return this.fetch(request);
  }

  Post(endpoint: string, body: any) {    
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Post,
    };
    
    return this.fetch(request);
  }

  Put(endpoint: string, body: any) {
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Put,
    };
    
    return this.fetch(request);
  }

  Delete(endpoint: string, body: any) {
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Delete,
    };
    
    return this.fetch(request);
  }

  Patch(endpoint: string, body: any) {
    const request: RequestData = {
      endpoint, 
      body,
      method: HttpMethods.Patch,
    };
    
    return this.fetch(request);
  }
}

export const apiService = new ApiService();
