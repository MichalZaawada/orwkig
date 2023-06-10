import React from 'react';
import './App.css';
import { List } from './apiClient/List';
import { ProductDTO } from './apiClient/data-contracts';


interface AppState {
  api: List,
  products: ProductDTO[]
  description?: string,
  quantity?: number
}

export class App extends React.Component<any, AppState> {
  constructor(props: any) {
    super(props)
    this.state = {
      api: new List({
        baseUrl: "http://localhost:5000",
      }),
      products: []
    }

    this.handleChangeDescription = this.handleChangeDescription.bind(this)
    this.handleChangeQuantity = this.handleChangeQuantity.bind(this)

    this.getProducts();
  }

  private getProducts = async () => {
    const products = await this.state.api.listList();
    this.setState({
      ...this.state,
      products: products.data
    });
  };

  private addProduct = async (data: any) => {
    const addedProduct = await this.state.api.listUpdate({
      Description: this.state.description,
      Quantity: this.state.quantity
    });
    var newProducts = this.state.products;
    newProducts.push(addedProduct.data);
    this.setState({
      ...this.state,
      products: newProducts
    });
  }

  private deleteProduct = async (product: ProductDTO) => {
    await this.state.api.listDelete({
      Id: product.id
    })
    const deletedProduct = this.state.products.indexOf(product);
    var newProducts = this.state.products;
    newProducts.splice(deletedProduct, 1);
    this.setState({
      ...this.state,
      products: newProducts
    });

  }

  handleChangeDescription(event: any) {
    this.setState({ description: event.target.value });
  }

  handleChangeQuantity(event: any) {
    this.setState({ quantity: event.target.value });
  }


  render() {
    return (
      <div className="App" >
        <div className="table-wrapper">
          <table className='table'>
            <thead>
              <tr>
                <th colSpan={3}>Moja lista zakupów</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td><input value={this.state.description} onChange={this.handleChangeDescription} /></td>
                <td><input value={this.state.quantity} onChange={this.handleChangeQuantity} type='number' min={0} /></td>
                <td>
                  <button type="submit" className='btn' onClick={this.addProduct}>
                    <span>
                      Add
                    </span>
                  </button>
                </td>
              </tr>
              {this.state.products?.map((product) => (
                <tr>
                  <td>{product.description}</td>
                  <td>{product.quantity}</td>
                  <td>
                    <button className="btn btn-delete" onClick={() => this.deleteProduct(product)}>
                      <span>Delete</span>
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>);
  }


}

export default App;
