import React, { Component } from "react";
import { Table, Button } from "reactstrap";
import axios from "axios";

class App extends Component {
  state = {
    processes: []
  };

  componentWillMount() {
    axios.get("http://localhost:8000/api/process").then(response => {
      this.setState({
        processes: response.data
      });
    });
  }

  render() {
    let processes = this.state.processes.map(process => {
      return (
        <tr key={process.processName}>
          <td>{process.processName}</td>
          <td>{process.startTime}</td>
          <td>{process.totalProcessorTime}</td>
          <td>{process.cpuUsage}</td>
          <td>{process.memoryUsage}</td>
          <td>
            <Button color="danger" size="sm">
              Kill
            </Button>
          </td>
        </tr>
      );
    });
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
          <tbody>{processes}</tbody>
        </Table>
      </div>
    );
  }
}

export default App;
