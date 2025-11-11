pipeline {
    agent any

    triggers {
        // Ejecutar automáticamente cuando se hace push a cualquier rama
        pollSCM('H/5 * * * *') // cada 5 minutos verifica cambios
    }

    environment {
        BuildConfiguration = 'Release'
        AppProject = 'Avantick.Desktop/Avantick.Desktop.csproj'
        TestsProject = 'Avantick.Desktop.Tests/Avantick.Desktop.Tests.csproj'
    }

    stages {
        stage('Setup .NET SDK') {
            steps {
                echo 'Instalando .NET 9 SDK...'
                sh 'dotnet --version || true'
            }
        }

        stage('Restore') {
            steps {
                echo 'Restaurando dependencias...'
                sh 'dotnet restore "${AppProject}"'
                sh 'dotnet restore "${TestsProject}"'
            }
        }

        stage('Build App') {
            steps {
                echo 'Compilando aplicación...'
                sh 'dotnet build "${AppProject}" -c ${BuildConfiguration} --no-restore'
            }
        }

        stage('Build Tests') {
            steps {
                echo 'Compilando pruebas unitarias...'
                sh 'dotnet build "${TestsProject}" -c ${BuildConfiguration} --no-restore'
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Ejecutando pruebas...'
                sh '''
                    dotnet test "${TestsProject}" \
                        -c ${BuildConfiguration} \
                        --no-build \
                        --logger "trx;LogFileName=test-results.trx" \
                        --collect "XPlat Code Coverage"
                '''
            }
            post {
                always {
                    junit '**/test-results.trx'
                }
            }
        }

        stage('Publish Coverage') {
            steps {
                echo 'Publicando cobertura de código...'
                // Aquí puedes integrar con Cobertura o SonarQube si lo deseas
            }
        }
    }

    post {
        always {
            echo 'Pipeline finalizado.'
        }
    }
}