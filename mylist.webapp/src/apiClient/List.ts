/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

import { ProductDTO } from "./data-contracts";
import { HttpClient, RequestParams } from "./http-client";

export class List<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags List
   * @name ListList
   * @request GET:/List
   */
  listList = (params: RequestParams = {}) =>
    this.request<ProductDTO[], any>({
      path: `/List`,
      method: "GET",
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags List
   * @name ListUpdate
   * @request PUT:/List
   */
  listUpdate = (
    query?: {
      Description?: string;
      /** @format int32 */
      Quantity?: number;
    },
    params: RequestParams = {},
  ) =>
    this.request<ProductDTO, any>({
      path: `/List`,
      method: "PUT",
      query: query,
      format: "json",
      ...params,
    });
  /**
   * No description
   *
   * @tags List
   * @name ListDelete
   * @request DELETE:/List
   */
  listDelete = (
    query?: {
      /** @format uuid */
      Id?: string;
    },
    params: RequestParams = {},
  ) =>
    this.request<void, any>({
      path: `/List`,
      method: "DELETE",
      query: query,
      ...params,
    });
}
