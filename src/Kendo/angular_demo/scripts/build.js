const { spawnSync } = require('node:child_process');

const timestamp = new Date().toISOString().replace('T', ' ').slice(0, 19) + ' UTC';
const result = spawnSync(process.execPath, [
  require.resolve('@angular/cli/bin/ng.js'),
  'build',
  `--define=__BUILD_TIMESTAMP__=${JSON.stringify(timestamp)}`,
  ...process.argv.slice(2),
], { stdio: 'inherit' });

if (result.error) {
  console.error(result.error);
}
process.exitCode = result.status ?? 1;
