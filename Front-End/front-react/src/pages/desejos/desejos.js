import {Component} from 'react'

import logo from './logo.png';
import imagem from './image.png'

import './desejo.css'

class Desejo extends Component{
    constructor(props){
        super(props)

        this.state = {
            listaDesejos: [],
            listaUsuarios: [],
            idUsuario: 0,
            descricaoDesejo: '',
            emailUsuario: ''
        }
    }

    listarDesejos(){

        fetch('http://localhost:5000/api/desejo')

        .then(resposta => resposta.json())

        .then(dados => this.setState({listaDesejos : dados}))

        .catch(erro => console.log(erro))
    }

    listarUsuarios = () => {

        fetch('http://localhost:5000/api/usuarios')

        .then(resposta => resposta.json())

        .then(dados => this.setState({listaUsuarios : dados}))

        .catch(erro => console.log(erro))
    }

    alterarEstado = (event) => {
        this.setState({idUsuario : event.target.value}, () => {
            console.log(this.state.idUsuario)
        })
    }

    alterarEstadoDesejo = (event) => {
        this.setState({descricaoDesejo : event.target.value}, () => {
            console.log(this.state.descricaoDesejo)
        })
    }

    cadastrarDesejo = (event) => {

        event.preventDefault()

        fetch('http://localhost:5000/api/desejo', {

            method: 'POST',

            body: JSON.stringify({ idUsuario: this.state.idUsuario, descricao: this.state.descricaoDesejo }),

            headers: {
                "Content-Type" : "application/json"
            }
        })

        .catch(erro => console.log(erro))

        .then(this.listarDesejos())

        .then(this.listarUsuarios())
    }

    componentDidMount(){
        this.listarDesejos();
        this.listarUsuarios();
    }

    render(){
        return(
            <div>
                <main>
                    <section className="listagem">
                        <div className="content display-flex">
                            <div className="listagem-logo">
                                <img src={logo} ></img>
                                <div className="lista">
                                    <div className="listagemDesejos">
                                        <div className="titulo">
                                            <h3>Desejo</h3>
                                            <h3>Usuário</h3>
                                        </div>
                                        {
                                            this.state.listaDesejos.map( (desejo) => {
                                                return(
                                                    <div className="desejos">
                                                        
                                                        <div className="desejo">
                                                            <p>{desejo.descricao}</p>
                                                        </div>

                                                        <div className="desejo-usuario">
                                                            <p>{desejo.idUsuarioNavigation.email}</p>
                                                        </div>
                                                        
                                                    </div>
                                                )
                                            } )
                                        }
                                    </div>
                                </div>
                            </div>

                            <div className="cadastrar-desejo">
                                <h4>Cadastre um Desejo</h4>
                                <div className="cadastro">
                                    <div className="cadastrar">
                                        <form onSubmit={this.cadastrarDesejo}>
                                            <input
                                                className="input-cadastro"
                                                value={this.state.descricaoDesejo}
                                                onChange={this.alterarEstadoDesejo}
                                                type="text"
                                            />
                                            
                                            <p>Escolha um usuário</p>
                                            <select className="selecionar" onChange={this.alterarEstado}>
                                                <option>Escolha um usuário</option>
                                                {
                                                    this.state.listaUsuarios.map( (usuario) => {
                                                        return(
                                                            <option onChange={this.alterarEstado} value={usuario.idUsuario}>{usuario.email}</option>
                                                        )
                                                    })
                                                }
                                            </select>

                                            <button type="submit" disabled={ this.state.idUsuario === 0 ? 'none' : '' }>Cadastrar</button>
                                        </form>
                                    </div>
                                    <div className="imagem">
                                        <img src={imagem}></img>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </section>
                </main>
            </div>
        )
    }
}

export default Desejo;