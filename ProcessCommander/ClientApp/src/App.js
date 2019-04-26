import React, { Component } from "react";
import { Table } from "reactstrap";

class App extends Component {
  render() {
    return (
      <div className="App container">
        <Table>
          <thead>
            <tr>
              <th>processName</th>
              <th>startTime</th>
              <th>totalProcessorTime</th>
              <th>cpuUsage</th>
              <th>memoryUsage</th>
              <th>actions</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>1</td>
              <td>2</td>
              <td>3</td>
              <td>4</td>
              <td>5</td>
              <td>
                <button color="danger" size="sm">
                  Delete
                </button>
              </td>
            </tr>
          </tbody>
        </Table>
      </div>
    );
  }
}

export default App;
